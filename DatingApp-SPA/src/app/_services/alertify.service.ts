import { Injectable } from '@angular/core';
import * as alertify from 'alertifyjs';


@Injectable({
  providedIn: 'root'
})
export class AlertifyService {

constructor() { }

confirm(message: string, okCallback: () => any){
  alertify.confirm(message, (e: any) => {
    if (e){
      okCallback();
    }else {}
  });

}

success(message: string){
  alertify.set('notifier', 'delay', 5);
  alertify.success(message);
}

error(message: string){

  alertify.set('notifier', 'delay', 5);

  alertify.error(message);
}

warning(message: string){
  alertify.set('notifier', 'delay', 5);
  alertify.warning(message);
}

message(message: string){
  alertify.set('notifier', 'delay', 5);
  alertify.message(message);
}

}
