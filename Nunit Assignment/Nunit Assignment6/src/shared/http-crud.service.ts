import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Post } from 'src/models/post';

@Injectable({
  providedIn: 'root'
})
export class HttpCRUDService {

  constructor(private http: HttpClient) { }

  async getPosts(): Promise<Observable<any>>{
    return this.http.get(`https://jsonplaceholder.typicode.com/posts`);
  }

  async getPost(id:number): Promise<Observable<any>> {
    return this.http.get(`https://jsonplaceholder.typicode.com/posts/${id}`);
  }

  async addPost(): Promise<Observable<any>> {
   return this.http.post<Post>(`https://jsonplaceholder.typicode.com/posts`, {id:3,userId:1,title:"ram",body:"raja"});
  }

  async updatePost(): Promise<Observable<any>>{
    return this.http.put<Post>(`https://jsonplaceholder.typicode.com/posts/2`, {id:2,userId:1,title:"ram",body:"raja"});
  }
  async deletePost(id:number): Promise<Observable<any>>{
    return this.http.delete<Post>(`https://jsonplaceholder.typicode.com/posts/${id}`);
  }
}
