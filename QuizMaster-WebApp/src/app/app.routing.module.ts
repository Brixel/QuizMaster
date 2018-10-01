import { NgModule }             from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PageNotFoundComponent } from './Pages/page-not-found/page-not-found.component';
import { SelectivePreloadingStrategyService } from './selective-preloading-strategy-service.service';


const appRoutes: Routes = [
    { path: '',
      redirectTo: '/quizes',
      pathMatch: 'full'
    },
    { path: '**', component: PageNotFoundComponent }
  ];
  

  @NgModule({
    imports: [
      RouterModule.forRoot(
        appRoutes,
        {
          enableTracing: false, // <-- debugging purposes only
          preloadingStrategy: SelectivePreloadingStrategyService
        }
      )
    ],
    exports: [
      RouterModule
    ]
  })
  export class AppRoutingModule { }