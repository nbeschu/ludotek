import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';

@Injectable()
export class MyHttpInterceptor implements HttpInterceptor {

    constructor( @Inject('BASE_URL') private baseUrl: string) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const url = this.baseUrl;
        req = req.clone({
            url: url + req.url
        });
        return next.handle(req);
    }
}