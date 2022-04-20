import { PhotosService } from '../services/photos.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dramas',
  templateUrl: './drama.html',
  styleUrls: ['./drama.scss']
})
export class DramasComponent implements OnInit {
  dramas:any = [];
  constructor(
    private photosService: PhotosService,
  ) { }

  ngOnInit() {

    this.photosService.getDramas().subscribe((data)=> {
      this.dramas = data;
    }
    )
  }
}
