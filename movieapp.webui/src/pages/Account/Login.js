import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { Button, Container, Form, FormGroup, Input, Label } from "reactstrap";
import Auth from "../../library/Auth/Auth";

function Login(props) {
  const [userName, setUserName] = useState("");
  const [password, setPassword] = useState("");
  var navigate = useNavigate();

  async function LoginAction() {
    var status = await Auth.Login(userName, password);

    if (status) {
      navigate("/");
    }
    else {
      alert("Lütfen kullanıcı adı ve şifrenizi kontrol ederek tekrar deneyin.");
    }
  }

  return (
    <Container>
      <div style={{ display: 'flex', justifyContent: 'center', alignItems: 'center', height: '100vh' }}>
        <Form inline style={{ width: "500px" }}>
          <FormGroup>
            <Label style={{ width: "100%", textAlign: "center", background: "#eee", padding: "20px", fontWeight: "bold", fontSize: "24px" }}>
              Giriş Formu
            </Label>
          </FormGroup>
          <FormGroup floating>
            <Input
              id="UserName"
              name="UserName"
              placeholder="Kullanıcı Adı"
              type="text"
              onChange={(evt) => setUserName(evt.target.value)}
            />
            <Label for="UserName">
              Kullanıcı Adı
            </Label>
          </FormGroup>
          {' '}
          <FormGroup floating>
            <Input
              id="Password"
              name="password"
              placeholder="Şifre"
              type="password"
              onChange={(evt) => setPassword(evt.target.value)}
            />
            <Label for="Password">
              Şifre
            </Label>
          </FormGroup>
          {' '}
          <Button onClick={LoginAction} color="success">
            Giriş Yap
          </Button>
          <Button onClick={() => navigate("/register")} style={{ float: "right" }} color="primary">
            Kayıt Ol
          </Button>
        </Form>
      </div>
    </Container>
  );
}

export default Login;
