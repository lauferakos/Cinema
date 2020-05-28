import { Component, OnInit, Inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ReservationService } from '../services/reservation.service';
import { Reservation } from '../models/reservation';
import { ProjectionService } from '../services/projection.service';
import { Projection } from '../models/projection';

@Component({
    selector: 'app-ticket',
    templateUrl: './ticket.component.html',
    styleUrls: ['./ticket.component.css']
})
/** ticket component*/
export class TicketComponent implements OnInit {
/** ticket ctor */
  reservations: Reservation[];
  viewerid: string;
  projections: Projection[];

  constructor(
    private _Activatedroute: ActivatedRoute,
    private _reservationService: ReservationService,
    private _projectionService: ProjectionService) {
    }
    async ngOnInit()  {
      this.viewerid = this._Activatedroute.snapshot.paramMap.get("viewerid");
      this.reservations = await this._reservationService.getReservations(this.viewerid);
      let projections: Projection[];
      this.projections = [];
      projections = await this._projectionService.getAllProjection();
      console.log(projections);

      for (var i = 0; i < this.reservations.length; i++) {
        this.projections.push(projections.find(proj => proj.id == this.reservations[i].projectionId));
      }
      console.log(this.projections);

    }
}
