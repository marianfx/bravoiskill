import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Skill } from '../shared-models/skill';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs/internal/Observable';
import { UserSkill } from 'src/app/modules/profile-reviews/models/userSkill';


@Injectable({ providedIn: 'root' })
export class SkillService {
  constructor(private http: HttpClient) {}

  getAllSkills() {
    return this.http
      .get<Skill[]>(`${environment.AppRoot}/skills`);
  }

  deleteSkill(id: number): Observable<void> {
    return this.http.delete<void>(`${environment.AppRoot}/skills/${id}`);
  }

  getSkillById(id: number){
    return this.http.get<Skill>(`${environment.AppRoot}/skills/${id}`);
  }

  getUserSkillByUserId(id: number){
    return this.http.get<UserSkill[]>(`${environment.AppRoot}/users/${id}/userskills`)
  }

  createSkill(skill: Skill){
    console.log(skill);
    return this.http.post(`${environment.AppRoot}/skills`,skill);
  }

  editSkill(id: number, skill: Skill): Observable<void>{
    return this.http.put<void>(`${environment.AppRoot}/skills/${id}`,skill);
  }
}
