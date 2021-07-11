import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
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
  form: FormGroup;

  constructor(private http : HttpClient,private fb: FormBuilder) {
    this.apiURL = 'http://localhost:5000';
    this.form = this.fb.group({
      businessEntityID: [''],
      name: [''],
      phoneNumber: ['', Validators.required],
      phoneNumberTypeID: ['', Validators.compose([Validators.required, Validators.min(1)])],
    });
  }

  ngOnInit(): void {

    this.http.get(`${ this.apiURL }/api/personphone`)
    .subscribe((response: any) => {
      this.personPhones = response.data.personPhoneObjects;
    });

   
  }

  getById(phoneNumberTypeID: number, phoneNumber: string){
    this.http.get(`${ this.apiURL }/api/personphone/${phoneNumber}/${phoneNumberTypeID}`)
    .subscribe((response: any) => {
      this.personPhone = response.data.personPhoneObject;
      this.form.controls['phoneNumber'].setValue(this.personPhone.phoneNumber);
      this.form.controls['businessEntityID'].setValue(this.personPhone.businessEntityID);
      this.form.controls['name'].setValue(this.personPhone.person.name);
      this.form.controls['phoneNumberTypeID'].setValue(this.personPhone.phoneNumberTypeID);
    });
  }

  salvar(){
    this.http.post(`${ this.apiURL }/api/personphone`, this.form.value)
    .subscribe((response: any) => {
      console.log(response)
    });
  }


}
