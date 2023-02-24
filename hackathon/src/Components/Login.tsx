import React from "react";
import { useState } from "react";
import { Grid, TextField, Button } from "@material-ui/core";
import { Formik, Form, Field, ErrorMessage } from "formik";
import * as yup from "yup";
import { Navigate } from "react-router-dom";
import DotLoader from "react-spinners/DotLoader";
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

export default function Login() {
  const [ToLand, setToLand] = useState(false);
  const [loading, setLoading] = useState(false);

  if (ToLand) {
    return <Navigate to="/search" />;
  }

  const initialValues = {
    email: "",
    password: "",
  };

  const validationSchema = yup.object().shape({
    email: yup
      .string()
      .required("Email ID is required")
      .email("MailId must be a valid email"),
    password: yup.string().required("Password is required"),
  });

  function onSubmit(data: any) {
    setLoading(true);
    fetch("https://localhost:7235/api/LoginContoller", {
      method: "POST",
      body: JSON.stringify(data),
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
        "Access-Control-Allow-Origin": "*",
        "Access-Control-Allow-Methods": "*",
      },
    }).then((response) => {
      response.json().then((result) => {
        console.warn("result", result);
        if (result === undefined || result === "Invalid Credentials") {
          console.log("Not Success");
          setTimeout(() => {
            setLoading(false);
          }, 4000);
          toast.error("Invalid credentials");
        } else if (result !== "Invalid Credentials") {
          console.log("Login Successful");
          toast.success("Login successful");
          setTimeout(() => {
            setLoading(false);
          }, 4000);
          setTimeout(() => {
            setToLand(true);
          }, 4000);
        }
        sessionStorage.setItem(
          "result",
          JSON.stringify({
            token: result,
          })
        );
      });
    });
  }

  return (
    <Grid>
      <Grid>
        <div className="imgbox">
          <img className="backgroungImg" alt="KANINI" src="../kanini-bg.jpeg" />
        </div>
        <img
          className="Bg"
          alt="Kanini Ticker Platform"
          src="../Group 5786.png"
        />
        <img
          className="Kaninibg"
          alt=" Kanini logo"
          src="../Group 427318265.png"
        />
        <p className="heading">Sign In</p>
        <p className="welcome">
          welcome back! please enter email id and password
        </p>
      </Grid>
      <Formik
        initialValues={initialValues}
        validationSchema={validationSchema}
        onSubmit={onSubmit}
      >
        <Form>
          {/* <div className="MuiOutlinedInput-root">   */}
          <p className="mailid"> Email ID</p>
          <div className="Input">
            <Field
              as={TextField}
              variant="outlined"
              label={""}
              name="email"
              helperText={<ErrorMessage name="email" />}
              fullWidth
              required
            />
          </div>
          <p className="password"> Password</p>
          <div className="Input2">
            <Field
              as={TextField}
              variant="outlined"
              label={""}
              type="password"
              name="password"
              helperText={<ErrorMessage name="password" />}
              fullWidth
              required
            />
          </div>
          <br />
          <div>
            <Button
              style={{
                borderRadius: 50,
                height: 52,
                width: 471,
                left: 450,
                top: 200,
                backgroundColor: "#0078FF",
                color: "white",
              }}
              type="submit"
              disabled={loading}
              variant="contained"
              role="button"
            >
              {loading && <DotLoader color={"#fff"} size={24} />}
              {!loading && "SIGN IN"}
            </Button>
          </div>
        </Form>
      </Formik>
      <br />
      <Grid className="Toastify__toast-container--top-right">
        <ToastContainer
          position="top-right"
          autoClose={2000}
          hideProgressBar={false}
          font-size="1px"
          newestOnTop={false}
          closeOnClick
          rtl={false}
          pauseOnFocusLoss
          draggable
          pauseOnHover
        />
      </Grid>
    </Grid>
  );
}
