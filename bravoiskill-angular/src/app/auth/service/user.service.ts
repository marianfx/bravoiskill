import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../models/user';
import { environment } from 'src/environments/environment';

@Injectable({ providedIn: 'root' })
export class UserService {
  constructor(private http: HttpClient) {}

  getAllUsers() {
    return this.http
      .get<User[]>(`${environment.AppRoot}/users`);
  }

  // postUser() {
  //   this.http.post(`${environment.AppRoot}/users`);
  // }
}
