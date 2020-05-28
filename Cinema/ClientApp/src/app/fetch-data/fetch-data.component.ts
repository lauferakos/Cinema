import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[];
  public films: Film[];
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Film[]>(baseUrl + 'film').subscribe(result => {
      this.films = result;
    }, error => console.error(error));
  }
}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
interface Film {
  id: number;
  title: string;
  director: string;
  description: string;
  rating: string;

}
