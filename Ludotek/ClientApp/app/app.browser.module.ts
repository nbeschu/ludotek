import { NgModule, NO_ERRORS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppModuleShared } from './app.shared.module';
import { AppComponent } from './components/app/app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FetchDataService } from './services/fetchdata.service';
import { MyHttpInterceptor } from './services/httpinterceptor.service';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { MDBBootstrapModule } from 'angular-bootstrap-md';

@NgModule({
    bootstrap: [ AppComponent ],
    imports: [
        BrowserModule,
        HttpClientModule,
        AppModuleShared,
        BrowserAnimationsModule,
        MDBBootstrapModule.forRoot()
    ],
    providers: [
        { provide: 'BASE_URL', useFactory: getBaseUrl },
        { provide: 'API_URL', useFactory: getApiUrl },
        { provide: HTTP_INTERCEPTORS, useClass: MyHttpInterceptor, multi: true },
        FetchDataService
    ],
    schemas: [NO_ERRORS_SCHEMA]
})
export class AppModule {
}

export function getApiUrl() {
    return (window as any).url_Config.apiUrl;
}

export function getBaseUrl() {
    return 'http://localhost:5151/';
}
