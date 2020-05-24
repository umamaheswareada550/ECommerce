import {
  HttpInterceptor,
  HttpEvent,
  HttpHandler,
  HttpRequest,
} from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { finalize } from "rxjs/operators";
import { LoadingScreenService } from "../loading-screen/loading-screen.service";

@Injectable()
export class LoadingScreenInterceptor implements HttpInterceptor {
  activeRequests = 0;

  /*
   * URLs for which the loading screen should not be enabled
   */
  skippUrls = ["/authrefresh"];

  constructor(private loadingScreenService: LoadingScreenService) {}

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    let displayLoadingScreen = true;

    for (const skipUrl of this.skippUrls) {
      if (new RegExp(skipUrl).test(req.url)) {
        displayLoadingScreen = false;
        break;
      }
    }

    if (displayLoadingScreen) {
      if (this.activeRequests === 0) {
        this.loadingScreenService.startLoading();
      }

      this.activeRequests++;
      return next.handle(req).pipe(
        finalize(() => {
          this.activeRequests--;
          if (this.activeRequests === 0) {
            this.loadingScreenService.stopLoading();
          }
        })
      );
    } else {
      return next.handle(req);
    }
  }
}
