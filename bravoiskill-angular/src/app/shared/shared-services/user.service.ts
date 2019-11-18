import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../shared-models/user';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class UserService {
  constructor(private http: HttpClient) {}

  getAllUsers() {
    return this.http.get<User[]>(`${environment.AppRoot}/users`);
  }

  getUserById(id: number){
    return this.http.get<User>(`${environment.AppRoot}/users/${id}`);
  }

  createUser(user: User){
    return this.http.post(`${environment.AppRoot}/users`,user);
  }

  editUser(id: number, user: User): Observable<void>{
    return this.http.put<void>(`${environment.AppRoot}/users/${id}`,user);
  }

  deleteUser(id: number): Observable<void> {
    return this.http.delete<void>(`${environment.AppRoot}/users/${id}`);
  }
}
