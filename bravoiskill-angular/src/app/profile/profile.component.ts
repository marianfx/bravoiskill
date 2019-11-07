import { empty } from "rxjs";
import { not } from "@angular/compiler/src/output/output_ast";
import { Component, OnInit } from '@angular/core';
import { User } from '../auth/models/user';
import { AuthenticationService } from '../auth/service/authentication.service';
import * as moment from 'moment';
import { ipInfo } from '../ipinfo';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { getDefaultService } from 'selenium-webdriver/chrome';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { UserService } from '../auth/service/user.service';

@Component({
  selector: "app-profile",
  templateUrl: "./profile.component.html",
  styleUrls: ["./profile.component.css"]
})
export class ProfileComponent implements OnInit {
  public cUser: User = {} as User;
  public ipData: ipInfo;
  public canMessage: boolean = false;
  token: String = 'df96ac341a7a8d';
  selectedFile: File = null;
  profilePhoto: String = "";
  private routeSub: Subscription;

  constructor(private authenticationService: AuthenticationService, public http: HttpClient, public route: ActivatedRoute, public userService: UserService) {
   // this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
  }

  ngOnInit() {
    this.getUserMet();
    this.SetIpAddress();
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
      console.log(params['id']) //log the value of id
      if(params && params['id']) {
        this.userService.getUserById(+(params['id'])).subscribe(user => {
          this.cUser = user;
          this.profilePhoto = "url('" + `${environment.AppRoot}/users/${user.userId}/photo` + "')";
          this.authenticationService.currentUser.subscribe(x => this.canMessage = ( x.userId != this.cUser.userId ));
          console.log(user);
        });
        console.log(this.cUser.userId);
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
        if (!x || !x["fileName"])
          return console.log ("Error");
        this.profilePhoto = "url('" + `${environment.AppRoot}/users/${this.cUser.userId}/photo` + "')";
      });
  }
  ngOnDestroy() {
    this.routeSub.unsubscribe();
  }
}
