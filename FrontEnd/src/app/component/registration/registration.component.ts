import { Component, OnInit } from '@angular/core';
import { RegistrationApiService } from '../../services/registration.service';
import { Router } from '@angular/router';
import { UserDao } from '../../data/userDao.model';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  constructor(private apiService:  RegistrationApiService, private router: Router) { } 

  registrationForm = new FormGroup({
    UserRole: new FormControl(2),
    Username: new FormControl(''),
    ClubName: new FormControl(''),
    FirstName: new FormControl(''),
    LastName: new FormControl(''),
    Country: new FormControl(''),
    City: new FormControl(''),
    Email: new FormControl(''),
    Password: new FormControl(''),
  });
  newUser : UserDao;
  message : string = "";

  ngOnInit() {
  }

  public onSubmit()
  {
    this.newUser = this.registrationForm.value;
    console.log(this.newUser);
    this.apiService.Register(this.newUser)
    .subscribe(
      data => {
        if (data['status'] == 'success')  {
          this.message = "Login success" ;
          console.log("error");  
        } else {
          console.log("error");
          this.message = data['message'];
        }
      },
      error => {
        if (error.status == 401) {
          console.log(error);
   //       this.apiService.logout();        
          this.router.navigate(['/login']);
        } else {
          this.message = error.message;
        } 
      }); 
  }

}
