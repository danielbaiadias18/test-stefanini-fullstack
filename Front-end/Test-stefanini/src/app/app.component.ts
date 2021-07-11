import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { iPersonPhone } from 'src/models/PersonPhone';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Test-stefanini';
  readonly apiURL : string;
  personPhones: iPersonPhone[] = [];
  personPhone: iPersonPhone = null;
  
  constructor(private http : HttpClient) {
    this.apiURL = 'http://localhost:5000';
  }

  ngOnInit(): void {

    this.http.get(`${ this.apiURL }/api/personphone`)
    .subscribe((response: any) => {
      this.personPhones = response.data.personPhoneObjects;
      console.log(this.personPhones, "pps")
      console.log(response)
    });

   
  }

  getById(phoneNumberTypeID: number, phoneNumber: string){
    this.http.get(`${ this.apiURL }/api/personphone/${phoneNumber}/${phoneNumberTypeID}`)
    .subscribe((response: any) => {
      this.personPhone = response.data.personPhoneObject;
      console.log(this.personPhone, "personPhonepersonPhonepersonPhonepersonPhonepersonPhone")
      console.log(response)
    });
  }


}
