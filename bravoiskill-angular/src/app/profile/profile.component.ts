import { Component, OnInit } from '@angular/core';
import { User } from '../auth/models/user';
import { AuthenticationService } from '../auth/service/authentication.service';
import * as moment from 'moment';
import { ipInfo } from '../ipinfo';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  public hidden: boolean = true;
  public currentUser: User;
  public ipData: ipInfo;
  token: String = 'df96ac341a7a8d';
  selectedFile: File = null;
  profilePhoto: String = "";

  constructor(private authenticationService: AuthenticationService, public http: HttpClient) {

    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);

  }

  ngOnInit() {
    this.SetIpAddress();
  }
  public CalculateAge(dateOfBirth: Date) {
    return moment().diff(dateOfBirth, 'year');
  }
  SetIpAddress() {
    this.http.get('https://ipinfo.io/?token=' + this.token).subscribe(data => {
      console.log(data);
      this.ipData = data as ipInfo;
    });
  }
  OnFileSelected(event) {
    console.log(event);
    this.selectedFile = <File>event.target.files[0];
  }
  OnUpload() {
    const fd = new FormData();
    fd.append('file', this.selectedFile, this.selectedFile.name)

    this.http.post(`${environment.AppRoot}/profileImage`, fd)
    .subscribe(res => {
      console.log(res);
      this.profilePhoto = this.selectedFile.name;
    });
    this.hidden = true;
  }
  OnEdit() {
    this.hidden = !this.hidden;
  }
}

