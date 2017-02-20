import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
 import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';


@Injectable()
export class DataService {

    public _pageSize: number;
    public _baseUri: string;

    constructor(public http: Http) {
      

    }

    set(baseUri: string, pageSize?: number): void {
        this._baseUri = 'http://localhost:5000/'+baseUri;
        this._pageSize = pageSize;
    }

    get(page: number) {
        var uri = this._baseUri + '/' + this._pageSize.toString();

        return this.http.get(uri)
            .map(this.extractData)
            .do(data => console.log('getData: ' + JSON.stringify(data)))
           // .catch(this.handleError);
    }
    getAll() {
        return this.http.get(this._baseUri) 
            .map(this.extractData)
            .do(data => console.log('All: ' + JSON.stringify(data)))
         //   .catch(this.handleError); 

    }

    post(data?: any, mapJson: boolean = true) {
        if (mapJson)
            return this.http.post(this._baseUri, data)
                .map(response => <any>(<Response>response).json())
                //.catch(this.handleError);
        else
            return this.http.post(this._baseUri, data);
    }

    delete(id: number) {

        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this.http.delete(this._baseUri + '/' + id.toString(),options)
            .map(response => <any>(<Response>response).json())
            .do(data => console.log('deleteData: ' + this._baseUri + id.toString() +' ='+ JSON.stringify(data)))
          //  .catch(this.handleError);
    }

    deleteResource(resource: string) {
        return this.http.delete(resource)
            .map(response => <any>(<Response>response).json())
    }


    private createProduct(any: any, options: RequestOptions): Observable<any> {
        any.id = undefined;
        return this.http.post(this._baseUri, any, options)
            .map(this.extractData)
            .do(data => console.log('createData: ' + JSON.stringify(data)))
           // .catch(this.handleError);
    }

    private updateProduct(any: any, options: RequestOptions): Observable<any> {
        const url = this._baseUri;
        return this.http.put(url, any, options)
            .map(() => any)
            .do(data => console.log('updatedata: ' + JSON.stringify(data)))
            //.catch(this.handleError);
    }



    private extractData(res: Response) {
        let body = res.json();
        return body.data || {};
    }
  //  private handleError(error: Response) {
        // in a real world app, we may send the server to some remote logging infrastructure
        // instead of just logging it to the console
    //    console.error(error);
      //  this.notificationService.printErrorMessage(Observable.throw(error.json().error).error);
        //return Observable.throw(error.json().error || 'Server error');
   // }
}