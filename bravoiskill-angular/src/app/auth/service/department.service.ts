import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Department } from '../models/department';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class DepartmentService {
  constructor(private http: HttpClient) {}

  getAllDepartments() {
    return this.http
      .get<Department[]>(`${environment.AppRoot}/departments`);
  }
  deleteDepartment(id: number): Observable<void> {
    return this.http.delete<void>(`${environment.AppRoot}/departments/${id}`);
  }
  getDepartmentById(id: number){
    return this.http.get<Department>(`${environment.AppRoot}/departments/${id}`);
  }

  createDepartment(department: Department){
    return this.http.post(`${environment.AppRoot}/departments`,department);
  }

  editDepartment(id: number, department: Department): Observable<void>{
    return this.http.put<void>(`${environment.AppRoot}/departments/${id}`,department);
  }

}
