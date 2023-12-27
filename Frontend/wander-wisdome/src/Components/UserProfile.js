import React, { useState, useEffect } from "react";
import axios from "axios";
import Navbar from "./Navbar";


export default function ProfileDeatils() {
  const [posts, setPosts] = useState([]);

  useEffect(() => {
    getPosts();
  }, []);

  const getPosts = () => {
    axios
      .get("https://localhost:7094/api/PostDetails/1")
      .then((res) => {
        const allData = res.data;
        setPosts(allData);
      })
      .catch((error) => {
        alert(error);
      });
  };

  return (
    <div className="container">
      <Navbar/>
      <ul>
        {posts
          ? posts.map((item) => {
              return (
                <div className="card" Style='margin-top:20px'>
                  <h5 className="card-header">{item.postTitle}</h5>
                  <div class="card-body">
                    <p class="card-text">
                     {item.postDescription}
                    </p>

                    <button type="button"  Style='margin-right:16px' class="btn btn-info">Like</button>
                    <button type="button" Style='margin-right:16px' class="btn btn-primary">Comment</button>
                    <button type="button"  Style='margin-right:16px' class="btn btn-danger">Delete</button>
                  </div>
                </div>
              );
            })
          : null}
      </ul>
    </div>
  );
}
