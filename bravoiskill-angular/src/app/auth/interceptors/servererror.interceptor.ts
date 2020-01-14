import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ServerErrorService } from '../service/servererror.service';


@Injectable()
export class ServerErrorInterceptor implements HttpInterceptor {
    constructor(private serverErrorService: ServerErrorService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request).pipe(catchError(err => {
            console.log(err);

            if (err.status === 500) {
                console.log(err.error.message);
                this.serverErrorService.showError(err);
            }

            const error = err.error ? err.error.message || err.statusText : 'Unknown error. Cannot continue';
            return throwError(error);
        }))
    }
}
