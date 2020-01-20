import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({ providedIn: 'root' })
export class ExportService {
  constructor(private http: HttpClient) {}

  getAllUsers() {
    return window.open(`${environment.AppRoot}/users/export`);
  }
  getAllDepartments() {
    return window.open(`${environment.AppRoot}/departments/export`);
  }
  getAllSkills() {
    return window.open(`${environment.AppRoot}/skills/export`);
  }


}
