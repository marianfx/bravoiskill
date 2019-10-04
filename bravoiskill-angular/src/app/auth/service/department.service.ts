import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Department } from '../models/department';

@Injectable({ providedIn: 'root' })
export class DepartmentService {
  constructor(private http: HttpClient) {}

  getAllDepartments() {
    return this.http
      .get<Department[]>(`${environment.AppRoot}/departments`);
  }

}
