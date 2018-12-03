import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/_models/User';
import { UserService } from '_services/user.service';
import { AlertifyService } from '_services/alertify.service';
import { ActivatedRoute } from '@angular/router';
import { NgxGalleryOptions, NgxGalleryImage, NgxGalleryAnimation } from 'ngx-gallery';

@Component({
  selector: 'app-member-detailed-card',
  templateUrl: './member-detailed-card.component.html',
  styleUrls: ['./member-detailed-card.component.css']
})
export class MemberDetailedCardComponent implements OnInit {

  user: User;
  galleryOptions: NgxGalleryOptions[];
    galleryImages: NgxGalleryImage[];
  constructor(private userService: UserService , private alerrtify: AlertifyService , private route: ActivatedRoute ) { }

  ngOnInit() {
    this.route.data.subscribe( data => { this.user = data['user']; });


    this.galleryOptions = [
      {
          width: '500px',
          height: '500px',
          thumbnailsColumns: 4,
          imagePercent: 100,
          imageAnimation: NgxGalleryAnimation.Slide,
          preview: false
      }];
      this.galleryImages = this.getImages() ;
  }
  getImages() {
    const imageUrls = [];
    for (let i = 0; i < this.user.photos.length; i++) {
      imageUrls.push({
        small: this.user.photos[i].url,
        medium: this.user.photos[i].url,
        big: this.user.photos[i].url,
        description: this.user.photos[i].description
      });
    }
    return imageUrls;
  }


  }



