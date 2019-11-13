import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Badge } from '../models/badge';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class BadgeService {
  constructor(private http: HttpClient) {}

  getAllBadges() {
    return this.http
      .get<Badge[]>(`${environment.AppRoot}/badges`);
  }
  deleteBadge(id: number): Observable<void> {
    return this.http.delete<void>(`${environment.AppRoot}/badges/${id}`);
  }
  getBadgeById(id: number){
    return this.http.get<Badge>(`${environment.AppRoot}/badges/${id}`);
  }

  createBadge(badge: Badge){
    return this.http.post(`${environment.AppRoot}/badges`,badge);
  }

  editBadge(id: number, badge: Badge): Observable<void>{
    return this.http.put<void>(`${environment.AppRoot}/badges/${id}`,badge);
  }

}
