import { Component, Inject, ViewChild, ElementRef, OnInit } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

@Component({
  selector: 'app-curling',
  templateUrl: './curling.component.html'
})

export class CurlingComponent implements OnInit {
  @ViewChild('canvas', { static: true })
  canvas: ElementRef<HTMLCanvasElement>;

  private ctx: CanvasRenderingContext2D;

  ngOnInit(): void {
   this.ctx = this.canvas.nativeElement.getContext('2d');
  }
  public http: HttpClient;
  public baseUrl: string
  public coordinates: PointDto[]
  public discNumber: number
  public radius: number

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
  }

  onSubmit(data) {
    this.discNumber = data.discNumber;
    this.radius = data.radius;
    this.fetchDiscCoordinates();
  }

  fetchDiscCoordinates() {
    const url = this.baseUrl + 'curling';
    var params = new HttpParams();
    params = params.set("discNumber", this.discNumber.toString());
    params = params.set("radius", this.radius.toString());
    this.http.get<PointDto[]>(url, { params: params })
      .subscribe(result => {
        this.coordinates = result;
        this.drawDiscs();
      }, error => console.error(error));
  }

  drawDiscs() {
    this.ctx.canvas.style.border = '1px solid #000';
    this.ctx.fillStyle = "#735beb";
    this.ctx.strokeStyle = "#000000";
    this.ctx.lineWidth = 3;
    this.ctx.translate(0, this.ctx.canvas.height);
    this.ctx.scale(1, -1);
    this.coordinates.forEach(centerPoint => {
      this.ctx.beginPath();
      this.ctx.arc(centerPoint.x, centerPoint.y, this.radius, 0, Math.PI * 2, true);
      this.ctx.closePath();
      this.ctx.fill();
      this.ctx.stroke();
    });
  }
}

interface PointDto {
  x: number;
  y: number;
}
