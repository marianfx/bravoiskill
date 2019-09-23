import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from './models/user.interface';

@Injectable()
export class UserService {
  constructor(public http: HttpClient) {}

  getUser(): Observable<User[]> {
    console.log(environment.AppRoot);
    return this.http.get<User[]>(environment.AppRoot + '/users');
  }
}
