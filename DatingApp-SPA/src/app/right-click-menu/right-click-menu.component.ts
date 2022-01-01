import { Component, OnInit, ViewChild } from '@angular/core';
import { MatMenuTrigger } from '@angular/material/menu';

@Component({
  selector: 'app-right-click-menu',
  templateUrl: './right-click-menu.component.html',
  styleUrls: ['./right-click-menu.component.css']
})
export class RightClickMenuComponent implements OnInit {
  
    title = 'demo-menu';
  
    // we create an object that contains coordinates
    menuTopLeftPosition =  {x: 0, y: 0}
  
    // reference to the MatMenuTrigger in the DOM
    @ViewChild(MatMenuTrigger, {static: true}) matMenuTrigger: MatMenuTrigger;
  
    /**
     * Method called when the user click with the right button
     * @param event MouseEvent, it contains the coordinates
     * @param item Our data contained in the row of the table
     */
    public onRightClick(event: MouseEvent, item) {
        // preventDefault avoids to show the visualization of the right-click menu of the browser
        event.preventDefault();
  
        // we record the mouse position in our object
        this.menuTopLeftPosition.x = event.clientX;
        this.menuTopLeftPosition.y = event.clientY;
  
        // we open the menu
        // we pass to the menu the information about our object
        this.matMenuTrigger.menuData = {item: item}
  
        // we open the menu
        this.matMenuTrigger.openMenu();
  
    }
  
    // number of lines to show for the example
    getExamples(n: number) {
      var arr = ['a', , 'c'];
var sparseKeys = Object.keys(arr);
var denseKeys = [...arr.keys()];
console.log(sparseKeys); // ['0', '2']
console.log(denseKeys);  // [0, 1, 2]
      return [ ...Array(n).keys()];
    }
  constructor() { }

  ngOnInit(): void {
  }

}
