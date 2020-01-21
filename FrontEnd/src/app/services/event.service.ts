import {Injectable} from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../data/users.model';
import { Event } from '../data/event.model';
import { LoginApiService } from './login.service';
import { AgeGroup } from '../data/ageGroup.model';
import { Category } from '../data/category.model';
import { Judoka } from '../data/judoka.model';
import { EventComponent } from '../component/event/event.component';

@Injectable()
export class EventApiService extends LoginApiService{

    public eventUrl : string = environment.apiHost+"/Event/";
    public ageGroupsUrl : string = environment.apiHost+"/agegroup/";

    public getEventList(){
        return this.http.get(this.eventUrl);
    }
    public getEvent(id:number){
        return this.http.get(this.eventUrl + id);
    }
    
    public createEvent(event: Event){
        const headers = new HttpHeaders().set('content-type', 'application/json');
        var body = {  
            EventType: 1,
            Title: event.Title,
            Description: event.Description,
            EntryFee: event.EntryFee,
            RegistrationStartDate: event.RegistrationStartDate,
            RegistrationEndDate: event.RegistrationEndDate,
            EventStartDate: event.EventStartDate  
     } 
        console.log(event);
        return this.http.post<Event>(this.eventUrl, body, { headers });
    }

    public getAgeGroups(){
        return this.http.get(this.ageGroupsUrl);
    }
    public getAgeGroupsByEvent(id: number){
        return this.http.get(this.eventUrl + id + '/AgeGroup');
    }
    
    public getUserEventAgeGroups(){
        return this.http.get(this.ageGroupsUrl);
    }
    public createAgeGroup(ageGroup: AgeGroup, categories: Category[]){
        const headers = new HttpHeaders().set('content-type', 'application/json');
        var body = {  
            Title:      ageGroup.Title,
            Gender:     ageGroup.Gender,
            YearsFrom:  ageGroup.YearsFrom,
            YearsTo:    ageGroup.YearsTo,
            EventID:    ageGroup.EventID,
            Categories:    categories
     } 
     console.log(body);
        return this.http.post<AgeGroup>(this.ageGroupsUrl, body, { headers });
    }
}