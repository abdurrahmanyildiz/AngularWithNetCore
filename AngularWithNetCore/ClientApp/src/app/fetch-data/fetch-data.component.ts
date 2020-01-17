import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ConfigService } from '../core/services/config.service';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[];

  constructor(http: HttpClient, private config: ConfigService) {
    http.get<WeatherForecast[]>(this.config.getApiUrl() + '/SampleData/WeatherForecasts').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }
}

interface WeatherForecast {
  dateFormatted: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
