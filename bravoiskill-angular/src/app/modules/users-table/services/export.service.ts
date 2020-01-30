import { Injectable, ɵCodegenComponentFactoryResolver } from '@angular/core';
import { HttpClient, HttpRequest, HttpHandler } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import * as FileSaver from 'file-saver';
import { Observable, of } from 'rxjs';
import { AuthenticationService } from 'src/app/auth/service/authentication.service';
import { map, catchError } from 'rxjs/operators';

@Injectable({ providedIn: 'root' })
export class ExportService {
  constructor(private http: HttpClient, private authServ: AuthenticationService) {}

  getAllUsers() {
    return window.open(`${environment.AppRoot}/users/export`);
  }
  getAllDepartments() {
    return window.open(`${environment.AppRoot}/departments/export`);
  }
  getAllSkills() {
    return window.open(`${environment.AppRoot}/skills/export`);
  }

  generateSpreadsheet(tableName: string): Observable<Object[]> {
    return Observable.create(observer => {
        let xhr = new XMLHttpRequest();

        xhr.open('GET', `${environment.AppRoot}/${tableName.toLowerCase()}s/export`, true);
        xhr.setRequestHeader('Authorization', "Bearer " + this.authServ.currentUserValue.token);
        xhr.setRequestHeader('Content-type', 'application/json');

        xhr.responseType='blob';


        xhr.onreadystatechange = function () {
            if (xhr.readyState === 4) {
                if (xhr.status === 200) {
                    var contentType = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet';
                    var blob = new Blob([xhr.response], { type: contentType });
                    observer.next(blob);
                    observer.complete();
                } else {
                    observer.error(xhr.response);
                }
            }
        }
        xhr.send();
    });
}

  exportData(tableName: string, fileName: string){
    return this.generateSpreadsheet(tableName)
    .pipe(
        map(data =>  {
          FileSaver.saveAs((data as unknown) as Blob, fileName);
          return data;
         }),
        catchError(error => {
          console.log("Error downloading the file.");
          return of(null);
        })
      );
    }
}
