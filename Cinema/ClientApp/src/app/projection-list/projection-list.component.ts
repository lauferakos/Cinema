import { Component, OnInit, Inject} from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProjectionService } from '../services/projection.service';
import { Projection } from '../models/projection';

@Component({
    selector: 'app-projection-list',
    templateUrl: './projection-list.component.html',
    styleUrls: ['./projection-list.component.css']
})
/** projection-list component*/
export class ProjectionListComponent implements OnInit {
  /** projection-list ctor */
  filmId: string;
  userid: string;
  projections: Projection[];
  constructor(private _Activatedroute: ActivatedRoute, private _projectionService: ProjectionService) {
    this.userid = sessionStorage.getItem('id');
    if (!this.userid) {
      this.userid = '0';
    }
  }
  async ngOnInit() {
    this.filmId = this._Activatedroute.snapshot.paramMap.get("filmId");
    console.log(this.filmId);
    this.projections = await this._projectionService.getProjectionsByFilmId(this.filmId);
    }


}
