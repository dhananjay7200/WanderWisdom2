import React from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";

function AddPost() {
    const navigate = useNavigate();
  const [post, setPost] = React.useState({
    postTitle: "string",
    postDescription: "string",
    isDeleted: 0,
    userIdFk: 1,
  });

  const addpost =(event)=>{
    event.preventDefault();

    axios
      .post("https://localhost:7094/api/PostDetails",post)
      .then((res) => {
        alert("" + res.data);
        navigate("/profile");
      })
      .catch((error) => {
        alert("fail to Add Post ");
      });

  }


  return (
    <div>
      <form onSubmit={addpost}>

  <div class="row mb-6" Style='margin-top:30px'>
    <div class="col">
      <div data-mdb-input-init class="form-outline">
        <input type="text" id="form6Example1" class="form-control" value={post.postTitle} onChange={e=>{setPost({...post,postTitle:e.target.value})}}/>
        <label class="form-label" for="form6Example1" >Title</label>
      </div>
    </div>
    </div>
    
  <div data-mdb-input-init class="form-outline mb-4">
    <textarea class="form-control" id="form6Example7" rows="4"  value={post.postDescription} onChange={e=>{setPost({...post,postDescription:e.target.value})}}></textarea>
    <label class="form-label" for="form6Example7">Post Description</label>
  </div>

  <button data-mdb-ripple-init type="submit" class="btn btn-primary btn-block mb-4">Post</button>
</form>
    </div>
  )
}

export default AddPost
