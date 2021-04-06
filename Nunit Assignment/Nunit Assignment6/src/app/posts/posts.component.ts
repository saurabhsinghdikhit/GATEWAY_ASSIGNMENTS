import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Post } from 'src/models/post';
import { HttpCRUDService } from 'src/shared/http-crud.service';

@Component({
  selector: 'app-posts',
  templateUrl: './posts.component.html',
  styleUrls: ['./posts.component.css']
})
export class PostsComponent implements OnInit {

  constructor(private service:HttpCRUDService) { }

  ngOnInit(){
  }
  async GetAllPosts(){
    return (await this.service.getPosts()).subscribe(val => console.log(val));
  }
  
  async GetSinglePost(id:number){
    return (await this.service.getPost(id)).subscribe(val => console.log(val));
  }
  async addPost(model:Post){
    return await this.service.addPost();
  }
  async updatePost(model:Post){
    return await this.service.updatePost();
  }
  async deletePost(id:number){
    return (await this.service.deletePost(id)).subscribe(val => console.log(val));
  }
}
