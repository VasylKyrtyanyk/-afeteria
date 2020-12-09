import { createStyles, CssBaseline, Grid, TextField, Theme, Typography, WithStyles, withStyles } from "@material-ui/core";
import * as React from "react";
import { connect } from "react-redux";
import { RouteComponentProps, withRouter } from "react-router";
import { Link } from "react-router-dom";
import { Button, Container } from "reactstrap";
import { ApplicationState } from "../../store";
import * as LoginStore from "../../store/Login";
import { makeStyles } from "@material-ui/core/styles";
import { compose } from "redux";

const styles = (theme: Theme) => createStyles({
  paper: {
    marginTop: theme.spacing(16),
    display: "flex",
    flexDirection: "column",
    alignItems: "center",
  },
  avatar: {
    margin: theme.spacing(1),
    backgroundColor: theme.palette.secondary.main,
  },
  form: {
    width: "35%", // Fix IE 11 issue.
    marginTop: theme.spacing(1),
  },
  submit: {
    margin: theme.spacing(3, 'auto', 2),
  },
});

type LoginProps = LoginStore.LoginState &
  typeof LoginStore.actionCreators &
  RouteComponentProps<{}> & WithStyles<typeof styles> & RouteComponentProps["history"];;



class Login extends React.PureComponent<LoginProps> {
  state = {
    username: "",
    password: "",
  };

  handleUsernameChange = (event: any) => {
    this.setState({ username: event.target.value });
  };

  handlePasswordChange = (event: any) => {
    this.setState({ password: event.target.value });
  };

  public render() {
    const style = this.props.classes;
    return (
      <Container component="main" maxWidth="xs">
        <CssBaseline />
        <div className={style.paper}>
          <Typography component="h1" variant="h5">
            Sign in
          </Typography>
          <form className={style.form} noValidate>
            <TextField
              variant="outlined"
              margin="normal"
              required
              fullWidth
              id="email"
              label="Email Address"
              name="email"
              autoComplete="email"
              onChange={(event) => this.handleUsernameChange(event)}
              autoFocus
            />
            <TextField
              variant="outlined"
              margin="normal"
              required
              fullWidth
              name="password"
              label="Password"
              type="password"
              id="password"
              onChange={(event) => this.handlePasswordChange(event)}
              autoComplete="current-password"
            />
            {/* <FormControlLabel
            control={<Checkbox value="remember" color="primary" />}
            label="Remember me"
          /> */}
            <Button
              type="submit"
              fullWidth
              variant="contained"
              color="primary"
              className={style.submit}
              onClick={() => this.ensureDataFetched()}
            >
              Sign In
            </Button>
            {/* <Grid container>
            <Grid item xs>
              <Link href="#" variant="body2">
                Forgot password?
              </Link>
            </Grid>
          </Grid> */}
          </form>
        </div>
      </Container>
    );
  }

  private ensureDataFetched() {
    const username = this.state.username;
    const password = this.state.password;
    this.props.requestLogin(username, password);
  }
}

export default compose(connect(
  (state: ApplicationState) => state.login, // Selects which state properties are merged into the component's props
  LoginStore.actionCreators // Selects which action creators are merged into the component's props
), withStyles(styles), withRouter)(Login as any);