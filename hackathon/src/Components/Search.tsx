import React from "react";
import { useState } from "react";
import { Navigate } from "react-router-dom";
import { Typography, Button, styled, Toolbar, AppBar } from "@material-ui/core";
import Paper from "@mui/material/Paper";
import InputBase from "@mui/material/InputBase";
import LockIcon from "@mui/icons-material/Lock";
import IconButton from "@mui/material/IconButton";
import SearchIcon from "@mui/icons-material/Search";

const StyledToolbar = styled(Toolbar)({
  display: "flex",
  justifyContent: "space-between",
});

function Search() {
  const [ToLand, setToLand] = useState(false);

  if (ToLand) {
    return <Navigate to="/login" />;
  }
  return (
    <div>
      <img className="SbgImage" alt="Simage" src="../Mask group.png" />
      <img className="RbgImage" alt="Rimage" src="../Rectangle 11941.png" />
      <img className="Iimage" alt="Iimage" src="../Group 427319065.png" />
      <img className="Aimage" alt="Aimage" src="../Group 427319262.png" />

      <Paper
        component="form"
        sx={{
          p: "2px 4px",
          display: "flex",
          alignItems: "center",
          width: 610,
          top: 330,
          position: "absolute",
          left: 480,
          borderRadius: 20,
        }}
      >
        <IconButton sx={{ p: "10px" }} aria-label="menu">
          <SearchIcon className="search" />
        </IconButton>
        <InputBase
          sx={{ ml: 1, flex: 1 }}
          placeholder="Search for stocks"
          inputProps={{ "aria-label": "search google maps" }}
        />
      </Paper>

      <AppBar position="fixed" className="bar">
        <StyledToolbar className="appbar">
          <Typography>
            <div>
              <div>
                <Typography variant="h6">
                  <img alt=" Kanini logo" src="../Group 427318265.png" />
                </Typography>
                <Button
                  style={{
                    borderRadius: 50,
                    height: 32,
                    width: 83,
                    color: "#0078FF",
                    borderColor: "#0078FF",
                  }}
                  type="submit"
                  variant="outlined"
                  role="button"
                  className="logout"
                  onClick={() => setToLand(true)}
                >
                  <LockIcon fontSize="small" />
                  logout
                </Button>
              </div>
            </div>
          </Typography>
        </StyledToolbar>
      </AppBar>
    </div>
  );
}

export default Search;
