import React from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";

export default function UserRegistration() {
  const navigate = useNavigate();
  const [user, SetUser] = React.useState({
    userName: "",
    userEmail: "",
    userPassword: "",
    userPhonenumber: "",
    userCity: "",
    userRole: "User",
    isDeleted: 0,
  });

  const register = (event) => {
    event.preventDefault();

    axios
      .post("https://localhost:7094/api/UserDetails",user)
      .then((res) => {
        alert("" + res.data);
        navigate("/");
      })
      .catch((error) => {
        alert("fail to register");
      });
  };

  return (
    <section class="text-center text-lg-start">
      <style></style>

      <div class="container py-4">
        <div class="row g-0 align-items-center">
          <div class="col-lg-6 mb-5 mb-lg-0">
            <div
              class="card cascading-right"
              Style="
                    background: hsla(0, 0%, 100%, 0.55);
                    backdrop-filter: blur(30px);
                    "
            >
              <div class="card-body p-5 shadow-5 text-center">
                <h2 class="fw-bold mb-5">Sign up now</h2>
                <form onSubmit={register}>
                  {/* <!-- 2 column grid layout with text inputs for the first and last names --> */}
                  <div class="row">
                    <div class="col-md-6 mb-4">
                      <div class="form-outline">
                        <input
                          type="text"
                          id="form3Example1"
                          class="form-control"
                          value={user.userName}
                          onChange={e=>{SetUser({...user,userName:e.target.value})}}
                        />
                        <label class="form-label" for="form3Example1">
                           Name
                        </label>
                      </div>
                    </div>
                    <div class="col-md-6 mb-4">
                      <div class="form-outline">
                        <input
                          type="text"
                          id="form3Example1"
                          class="form-control"
                          value={user.userPhonenumber}
                          onChange={e=>{SetUser({...user,userPhonenumber:e.target.value})}}
                        />
                        <label class="form-label" for="form3Example1">
                           Phone Number
                        </label>
                      </div>
                    </div>
                    <div class="col-md-6 mb-4">
                      <div class="form-outline">
                        <input
                          type="text"
                          id="form3Example1"
                          class="form-control"
                          value={user.userCity}
                          onChange={e=>{SetUser({...user,userCity:e.target.value})}}
                        />
                        <label class="form-label" for="form3Example1">
                           City
                        </label>
                      </div>
                    </div>
                    
                  </div>

                  {/* <!-- Email input --> */}
                  <div class="form-outline mb-4">
                    <input
                      type="email"
                      id="form3Example3"
                      class="form-control"
                      value={user.userEmail}
                      onChange={e=>{SetUser({...user,userEmail:e.target.value})}}
                    />
                    <label class="form-label" for="form3Example3">
                      Email address
                    </label>
                  </div>

                  {/* <!-- Password input --> */}
                  <div class="form-outline mb-4">
                    <input
                      type="password"
                      id="form3Example4"
                      class="form-control"
                      value={user.userPassword}
                      onChange={e=>{SetUser({...user,userPassword:e.target.value})}}
                    />
                    <label class="form-label" for="form3Example4">
                      Password
                    </label>
                  </div>

                  {/* <!-- Checkbox --> */}
                  <div class="form-check d-flex justify-content-center mb-4">
                    <input
                      class="form-check-input me-2"
                      type="checkbox"
                      value=""
                      id="form2Example33"
                      checked
                    />
                    <label class="form-check-label" for="form2Example33">
                      Agree Term & condition
                    </label>
                  </div>

                  {/* <!-- Submit button --> */}
                  <button type="submit" class="btn btn-primary btn-block mb-4">
                    Sign up
                  </button>
                </form>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
  );
}
