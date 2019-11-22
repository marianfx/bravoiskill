import { Component, OnInit } from "@angular/core";
import { User } from "../../../shared/shared-models/user";
import { AuthenticationService } from "../../../auth/service/authentication.service";
import * as moment from "moment";
import { ipInfo } from "../models/ipinfo";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { ActivatedRoute } from "@angular/router";
import { Subscription } from "rxjs";
import { UserService } from "../../../shared/shared-services/user.service";
import { DomSanitizer } from "@angular/platform-browser";
import { Review } from "../../profile-reviews-table/models/review";
import { BadgeService } from "../services/badge.service";
import { Badge } from "../models/badge";
import { SelectItem } from 'primeng/api';

@Component({
  selector: "app-profile",
  templateUrl: "./profile.component.html",
  styleUrls: ["./profile.component.css"]
})
export class ProfileComponent implements OnInit {
  public reviews: Review[];
  public cUser: User = {} as User;
  public ipData: ipInfo;
  public canMessage: boolean = false;
  token: String = "df96ac341a7a8d";
  selectedFile: File = null;
  profilePhoto: String = "";
  private routeSub: Subscription;
  public currentBadge: Badge = {} as Badge;
  currentBadgeColor: String;
  user: User = {} as User;
  public availableBadges: Badge[] = [] as Badge[];
  public availableBadgesDescription: SelectItem[] = [];
  displayDialogueB: boolean;

  availableColors: String[] = [
    "red",
    "green",
    "black",
    "blue",
    "pink",
    "purple",
    "orange",
    "indigo",
    "magenta"
  ];

  constructor(
    private authenticationService: AuthenticationService,
    public http: HttpClient,
    public route: ActivatedRoute,
    public userService: UserService,
    private sanitizer: DomSanitizer,
    public badgeService: BadgeService
  ) {
    // this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
  }

  ngOnInit() {
    this.getUserMet();
    this.SetIpAddress();
    this.setRandomBadgeColor();
  }

  refreshProfilePhoto(){
    this.profilePhoto = "url('" + `${environment.AppRoot}/users/${this.cUser.userId}/photo` + "')";
  }

  refreshActiveBadge(){
    this.badgeService.getActiveBadgeById(this.cUser.badgeId).subscribe(x => (this.currentBadge = x));
  }

  setRandomBadgeColor() {
    this.currentBadgeColor = this.availableColors[this.getRandomInt(this.availableColors.length - 1)];
  }

  getRandomInt(max: number) {
    return Math.floor(Math.random() * max);
  }

  public CalculateAge(dateOfBirth: Date) {
    return moment().diff(dateOfBirth, "year");
  }

  SetIpAddress() {
    this.http.get("https://ipinfo.io/?token=" + this.token).subscribe(data => {
      console.log(data);
      this.ipData = data as ipInfo;
    });
  }

  getUserMet() {
    // // this.route
    // get route parameter
    // check id not null
    // get user by id using user service
    // populate curentUser with resulted user
    this.routeSub = this.route.params.subscribe(params => {
      // console.log(params) //log the entire params object
      // console.log(params['id']) //log the value of id
      if (params && params["id"]) {
        this.userService.getUserById(+params["id"]).subscribe(user => {
          this.cUser = user;
          this.refreshActiveBadge();
          this.badgeService.getAllBadgesFor(this.cUser.userId).subscribe(x => {
            this.availableBadges = x;
            for (let index = 0; index < this.availableBadges.length; index++) {
              this.availableBadgesDescription.push({label: this.availableBadges[index].description, value:this.availableBadges[index]} as SelectItem);
            }
          });
          this.refreshProfilePhoto();
          this.authenticationService.currentUser.subscribe(
            x => (this.canMessage = x.userId != this.cUser.userId)
          );
        });
      }
    });
  }

  OnFileSelected(event) {
    console.log(event);
    this.selectedFile = <File>event.target.files[0];
    this.OnUpload(this.cUser.userId);
  }

  OnUpload(id: number) {
    const fd = new FormData();
    fd.append("file", this.selectedFile, this.selectedFile.name);
    this.profilePhoto = "url('assets/images/loading.gif')";
    this.http
      .post(`${environment.AppRoot}/users/${id}/photo`, fd)
      .subscribe(x => {
        if (!x || !x["fileName"]) return console.log("Error");
        this.refreshProfilePhoto();
      });
  }

  ngOnDestroy() {
    this.routeSub.unsubscribe();
  }

  skype(skype: String) {
    return this.sanitizer.bypassSecurityTrustUrl("skype:" + skype + "?chat");
  }

  saveCurrentBadgeEdit(id: number, user: User) {

    user.badgeId = this.currentBadge.badgeId;
    ///edit user in back-end
    this.userService.editUser(id, user).subscribe(
      response => {
        console.log(response);
        this.setRandomBadgeColor();
        this.refreshActiveBadge();
      },
      error => console.log(error)
    );
    ///

    this.displayDialogueB = false;
  }
  editBadge() {
    if(this.canMessage == false)
    this.displayDialogueB = true;
  }
}
