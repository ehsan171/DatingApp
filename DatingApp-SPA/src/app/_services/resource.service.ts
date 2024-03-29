import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Allocation } from '../_models/allocation';
import { Resource } from '../_models/resource';


const httpOptions = {
  headers: new HttpHeaders({
   
    Authorization: 'Bearer ' + localStorage.getItem('token')
  })

};
@Injectable({
  providedIn: 'root'
})
export class ResourceService {

  baseUrl = environment.apiUrl;


  constructor(
    private http: HttpClient,
    private httpClient: HttpClient
  ) { }

  getResources(): Observable<Resource[]> {
    
     return this.http.get<Resource[]>(this.baseUrl + 'resource/getAllResources', httpOptions);
   }
  getResource(resourceId): Observable<Resource[]> {
    console.log(this.baseUrl + 'resource/getResource/'+resourceId);
   
    
     return this.http.get<Resource[]>(this.baseUrl + 'resource/getResource/'+resourceId, httpOptions);
   }
  getAllocations(resourceId, year, month): Observable<Allocation[]> {
    console.log(this.baseUrl  + 'allocation/GetAllAllocationsByResourceYearMonth/'+resourceId + '/' + year + '/' + month, httpOptions)
     return this.http.get<Allocation[]>(this.baseUrl  + 'allocation/GetAllAllocationsByResourceYearMonth/'+resourceId + '/' + year + '/' + month, httpOptions);
   }
  getWaitingAllocationsForColor(resourceId, year, month): Observable<Allocation[]> {
    console.log(this.baseUrl  + 'allocation/GetAllWaitingAllocationsByResourceYearMonthForColor/'+resourceId + '/' + year + '/' + month, httpOptions)
     return this.http.get<Allocation[]>(this.baseUrl  + 'allocation/GetAllWaitingAllocationsByResourceYearMonthForColor/'+resourceId + '/' + year + '/' + month, httpOptions);
   }
  getWaitingAllocationsForEachBarname(resourceId: number, year: number, month: number, barnameId: number): Observable<Allocation[]> {
    console.log(this.baseUrl  + 'allocation/GetAllWaitingAllocationsByResourceYearMonthForEachBarname/'+resourceId + '/' + year + '/' + month + '/' + barnameId, httpOptions)
     return this.http.get<Allocation[]>(this.baseUrl  + 'allocation/GetAllWaitingAllocationsByResourceYearMonthForEachBarname/'+resourceId + '/' + year + '/' + month+ '/' + barnameId, httpOptions);
   }

  getWaitingRequestAllocations(resourceId, year, month): Observable<Allocation[]> {
   console.log(this.baseUrl  + 'allocation/GetAllWaitingRequestByResourceYearMonthForAccepting/'+resourceId + '/' + year + '/' + month, httpOptions)
     return this.http.get<Allocation[]>(this.baseUrl  + 'allocation/GetAllWaitingRequestByResourceYearMonthForAccepting/'+resourceId + '/' + year + '/' + month, httpOptions);
   }
  
   acceptRequest(resourceId, year, month, day,  barnameId): Observable<Allocation[]> {
   console.log(this.baseUrl  + 'allocation/acceptRequest/'+resourceId + '/' + year + '/' + month+ '/' + day+ '/' + barnameId, httpOptions)
     return this.http.get<Allocation[]>(this.baseUrl  + 'allocation/acceptRequest/'+resourceId + '/' + year + '/'  + month+ '/' + day+ '/' + barnameId, httpOptions);
   }
  
   rejectRequest(resourceId, year, month, day,  barnameId): Observable<Allocation[]> {
   console.log(this.baseUrl  + 'allocation/rejectRequest/'+resourceId + '/' + year + '/' + month+ '/' + day+ '/' + barnameId, httpOptions)
     return this.http.get<Allocation[]>(this.baseUrl  + 'allocation/rejectRequest/'+resourceId + '/' + year + '/'  + month+ '/' + day+ '/' + barnameId, httpOptions);
   }
  
   deleteRequestByGroup(resourceId, year, month, day,  barnameId): Observable<Allocation[]> {
   console.log(this.baseUrl  + 'allocation/DeleteWaitingAllocationsByResourceYearMonthDayForEachBarname/'+resourceId + '/' + year + '/' + month+ '/' + day+ '/' + barnameId, httpOptions)
     return this.http.get<Allocation[]>(this.baseUrl  + 'allocation/DeleteWaitingAllocationsByResourceYearMonthDayForEachBarname/'+resourceId + '/' + year + '/'  + month+ '/' + day+ '/' + barnameId, httpOptions);
   }
  
   getFreeResourcePerHour(resourceId, year, month, day): Observable<Allocation[]> {
     return this.http.get<Allocation[]>(this.baseUrl  + 'allocation/GetFreeResourceByResourceYearMonthDay/'+resourceId + '/' + year + '/' + month + '/' + day, httpOptions);
   }

  getAcceptedAllocations(resourceId, year): Observable<Allocation[]> {
   console.log(this.baseUrl  + 'allocation/GetAllAcceptedAllocationsByResourceYear/'+resourceId + '/' + year , httpOptions)
     return this.http.get<Allocation[]>(this.baseUrl  + 'allocation/GetAllAcceptedAllocationsByResourceYear/'+resourceId + '/' + year , httpOptions);
   }

   registerAllocation(model: any){

    console.log("10001",model[0])
    console.log("nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn")
 
    return this.http.post(this.baseUrl + 'allocation/register', model);
  }


}
