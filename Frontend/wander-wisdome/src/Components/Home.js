import React, { useState, useEffect } from "react";
import axios from "axios";
import Navbar from "./Navbar";
import '../styles/home.css';

export default function HomePage(){

  const [posts, setPosts] = useState([]);

  useEffect(() => {
    getPosts();
  }, []);

  const getPosts = () => {
    axios
      .get("https://localhost:7094/api/PostDetails")
      .then((res) => {
        const allData = res.data;
        setPosts(allData);
      })
      .catch((error) => {
        alert(error);
      });
    }

    return (
        
        <div class="containerr container-fluid">
        <Navbar/>
        <div class="row" >
        <div class="col-4"><img src="" /><div class="card" Style="width: 18rem;">
  <img src="..." class="card-img-top" alt="..."/>
  <div class="card-body" Style='margin-top:20px'>
    <h5 class="card-title">Your Profile</h5>
    <p class="card-text">you can see all your post you can edit it delete it and see comments on your post</p>
    <a href="/profile"  class="btn btn-primary position-relative">
  Wander Profile
  <span class="position-absolute top-0 start-100 translate-middle p-2 bg-danger border border-light rounded-circle">
    <span class="visually-hidden">New alerts</span>
  </span>
</a>
  </div>
</div>
<div class="card" Style="width: 18rem;margin-top:20px;" >
  <img src="..." class="card-img-top" alt="..."/>
  <div class="card-body" >
    <h5 class="card-title">Add Post/Blog</h5>
    <p class="card-text">You can Add Post /Blog you want with proper title.</p>
    <a href="#" class="btn btn-primary">Add Post</a>
  </div>
</div>
<div class="card" Style="width: 18rem;margin-top:20px;">
  <img src="..." class="card-img-top" alt="..."/>
  <div class="card-body" Style='margin-top:20px'>
    <h5 class="card-title">Card title</h5>
    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
    <a href="#" class="btn btn-primary">Go somewhere</a>
  </div>
</div>
</div>
          <div class="col-8">
          <div>
      
      <ul>
        {posts
          ? posts.map((item) => {
              return (
                <div class="card" Style='margin-top:20px'>
                  <h5 class="card-header">{item.postTitle}</h5>
                  <div class="card-body">
                    <p class="card-text">
                     {item.postDescription}
                    </p>

                    <button type="button"  Style='margin-right:16px' class="btn btn-danger">Like</button>
                    <button type="button" Style='margin-right:16px' class="btn btn-primary">Comment</button>
                  </div>
                </div>
              );
            })
          : null}
      </ul>
    </div>
          </div>
         
        </div>
      </div>

    );
}