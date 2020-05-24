import { Component, OnDestroy, ElementRef, ChangeDetectorRef, OnInit, AfterViewInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { LoadingScreenService } from './loading-screen.service';
import { debounceTime, debounce } from 'rxjs/operators';

@Component({
  selector: 'app-loading-screen',
  templateUrl: './loading-screen.component.html',
  styleUrls: ['./loading-screen.component.scss']
})
export class LoadingScreenComponent implements OnInit, AfterViewInit, OnDestroy {

  debounceTime = 200;
  loading = false;
  loadingSubscription: Subscription;

  constructor(private loadingSubscriptionService: LoadingScreenService,
              private elemRef: ElementRef,
              private changeDetectorRef: ChangeDetectorRef) { }

  ngOnInit(): void {
    this.loadingSubscription = this.loadingSubscriptionService.loadingStatus
    .pipe(debounceTime(200))
    .subscribe((value) => {
      this.loading = value;
    });
  }

  ngAfterViewInit(): void {
    this.elemRef.nativeElement.style.display = 'none';
    this.loadingSubscription = this.loadingSubscriptionService.loadingStatus
    .pipe(debounceTime(this.debounceTime))
    .subscribe((status: boolean) => {
      this.elemRef.nativeElement.style.display = status ? 'block' : 'none';
      this.changeDetectorRef.detectChanges();
    });
  }

  ngOnDestroy() {
    this.loadingSubscription.unsubscribe();
  }

}
