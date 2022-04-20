import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PhotosService {

  constructor(private http: HttpClient) { 


  }
  getDramas (){
    return this.http.get('https://localhost:7188/api/Drama');
  }
}
