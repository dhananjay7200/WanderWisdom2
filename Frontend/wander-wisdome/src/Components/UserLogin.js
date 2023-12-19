import axios from 'axios';
import { jwtDecode } from 'jwt-decode';
import React from 'react';
import '../styles/login.css';
 import { Navigate, useNavigate } from 'react-router-dom';

export default function UserLogin(){
     const navigate=useNavigate();
    const[user,SetUser]=React.useState({user_Email:"",Password:""});

    

    const LoginHandle=(event)=>{

        event.preventDefault();

        axios.post("https://localhost:7094/api/UserDetails/login",user).then(res=>{sessionStorage.setItem("Token",res.data);
        var token=sessionStorage.getItem("Token");
        var decodedToken=jwtDecode(token);
        if(decodedToken.role=="User"){
            navigate("/Home")
        }}).catch(erroe=>{
            alert("Wrong username or password");
          })


    };


    return (
        
  
        <section class="text-center text-lg-start" Style="baclgrounf:black">
          <style>
          
          </style>
        
    
          <div class="container py-4">
            <div class="row g-0 align-items-center">
              <div class="col-lg-6 mb-5 mb-lg-0">
                <div class="card cascading-right" Style="
                    background: hsla(0, 0%, 100%, 0.55);
                    backdrop-filter: blur(30px);
                    ">
                  <div class="card-body p-5 shadow-5 text-center">
                    <h2 class="fw-bold mb-5">Sign In</h2>
                    <form onSubmit={LoginHandle}>
                      
                      {/* <!-- Email input --> */}
                      <div class="form-outline mb-4">
                        <input type="email" id="form3Example3" value={user.user_Email} class="form-control" onChange={e=>{SetUser({...user,user_Email:e.target.value})}} />
                        <label class="form-label" for="form3Example3">Email address</label>
                      </div>
        
                      {/* <!-- Password input --> */}
                      <div class="form-outline mb-4">
                        <input type="password" id="form3Example4" value={user.Password} class="form-control" onChange={e=>{SetUser({...user,Password:e.target.value})}}/>
                        <label class="form-label" for="form3Example4">Password</label>
                      </div>
        
                      
        
                      {/* <!-- Submit button --> */}
                      <button type="submit" class="btn btn-primary btn-block mb-4">
                        Sign In
                      </button>
                    </form>
                  </div>
                </div>
              </div>
        
              <div class="col-lg-6 mb-5 mb-lg-0">
                <img src="https://mdbootstrap.com/img/new/ecommerce/vertical/004.jpg" class="w-100 rounded-4 shadow-4"
                  alt="" />
              </div>
            </div>
          </div>
         
        </section>
     
       
  );
}
