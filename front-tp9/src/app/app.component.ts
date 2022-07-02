import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'front-tp9';

  constructor(private routers: Router, private route: ActivatedRoute){

  }

  crear(){
    this.routers.navigate(['crear'],{relativeTo: this.route.parent});
  }

  editar(){

  }

  eliminar(){

  }
}


