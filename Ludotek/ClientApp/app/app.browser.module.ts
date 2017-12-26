import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppModuleShared } from './app.shared.module';
import { AppComponent } from './components/app/app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FetchDataService } from './services/fetchdata.service';
import { MyHttpInterceptor } from './services/httpinterceptor.service';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';

@NgModule({
    bootstrap: [ AppComponent ],
    imports: [
        BrowserModule,
        HttpClientModule,
        AppModuleShared,
        BrowserAnimationsModule
    ],
    providers: [
        { provide: 'BASE_URL', useFactory: getBaseUrl },
        { provide: HTTP_INTERCEPTORS, useClass: MyHttpInterceptor, multi: true },
        FetchDataService
    ]
})
export class AppModule {
}

export function getBaseUrl() {
    return 'http://localhost:5151/';
}
