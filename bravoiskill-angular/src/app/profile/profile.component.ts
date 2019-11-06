import { Component, OnInit } from "@angular/core";
import { User } from "../auth/models/user";
import { AuthenticationService } from "../auth/service/authentication.service";
import * as moment from "moment";
import { ipInfo } from "../ipinfo";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { empty } from "rxjs";
import { not } from "@angular/compiler/src/output/output_ast";

@Component({
  selector: "app-profile",
  templateUrl: "./profile.component.html",
  styleUrls: ["./profile.component.css"]
})
export class ProfileComponent implements OnInit {
  public hidden: boolean = true;
  public currentUser: User;
  public ipData: ipInfo;
  token: String = "df96ac341a7a8d";
  selectedFile: File = null;
  profilePhoto: String = "url('assets/img/theme/team-4-800x800.jpg')";

  constructor(
    private authenticationService: AuthenticationService,
    public http: HttpClient,
  ) {
    this.authenticationService.currentUser.subscribe(
      x => {
        this.currentUser = x;
        this.profilePhoto = "url('" + `${environment.AppRoot}/users/${x.userId}/photo` + "')";
      }
    );
  }

  ngOnInit() {
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

  OnFileSelected(event) {
    console.log(event);
    this.selectedFile = <File>event.target.files[0];
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
            this.profilePhoto = "url('" + `${environment.AppRoot}/users/${this.currentUser.userId}/photo` + "')";
      });

    this.hidden = true;
  }

  OnEdit() {
    this.hidden = !this.hidden;
  }
}
