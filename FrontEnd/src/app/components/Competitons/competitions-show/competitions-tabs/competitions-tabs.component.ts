import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-competitions-tabs',
  templateUrl: './competitions-tabs.component.html',
  styleUrls: ['./competitions-tabs.component.css']
})
export class CompetitionsTabsComponent implements OnInit {

  navLinks: any[];
  activeLinkIndex = -1;

  constructor(private router: Router) { 

    this.navLinks = [
      {
        label: 'Information',
        link: './info',
        index: 0
      },
      {
        label: 'My Competitors',
        link: './my-competitors',
        index: 1
      }, 
      {
        label: 'Age Groups',
        link: './age-groups',
        index: 2
      }, 
      {
        label: 'Competitors',
        link: './competitors',
        index: 3
      },
      {
        label: 'Results',
        link: './results',
        index: 4
      },
  ];

  }

  ngOnInit(): void {
    this.router.events.subscribe((res) => {
        this.activeLinkIndex = this.navLinks.indexOf(this.navLinks.find(tab => tab.link === '.' + this.router.url));
    });
  }

}
