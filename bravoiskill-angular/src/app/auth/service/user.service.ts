import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../models/user';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';

@Injectable({ providedIn: 'root' })
export class UserService {
  constructor(private http: HttpClient) {}

  getAllUsers() {
    return this.http
      .get<User[]>(`${environment.AppRoot}/users`);
  }

  getUserById(id: number){
    return this.http.get<User>(`${environment.AppRoot}/users/${id}`);
  }

  createUser(user: User){
    return this.http.post(`${environment.AppRoot}/users`,user);
  }
  
  editUser(id: number, user: User){
    return this.http.put(`${environment.AppRoot}/users/${id}`,user);
  }

  deleteUser(id: number) {
    return this.http.delete(`${environment.AppRoot}/users`);
  }
}
