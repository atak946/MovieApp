import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { Button, Container, Form, FormGroup, Input, Label } from "reactstrap";
import Auth from "../../library/Auth/Auth";

function Register(props) {
    const [userName, setUserName] = useState("");
    const [password, setPassword] = useState("");
    const [email, setEmail] = useState("");

    var navigate = useNavigate();

    async function RegisterAction() {
        var status = await Auth.Register(userName, password, email);

        if (status === true) {
            navigate("/");
        }
        else {
            var errors = "";

            for (let index = 0; index < status.length; index++) {
                errors += status[index].description + "\r\n";                
            }

            alert(errors);
        }
    }

    return (
        <Container>
            <div style={{ display: 'flex', justifyContent: 'center', alignItems: 'center', height: '100vh' }}>
                <Form inline style={{ width: "500px" }}>
                    <FormGroup>
                        <Label style={{width:"100%", textAlign:"center", background: "#eee", padding:"20px", fontWeight: "bold", fontSize: "24px"}}>
                            Kayıt Formu
                        </Label>
                    </FormGroup>
                    <FormGroup floating>
                        <Input
                            id="Email"
                            name="Email"
                            placeholder="Email"
                            type="email"
                            onChange={(evt) => setEmail(evt.target.value)}
                        />
                        <Label for="exampleEmail">
                            Email
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
                        <Label for="exampleEmail">
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
                    <Button onClick={RegisterAction} color="success">
                        Kayıt Ol
                    </Button>
                    <Button onClick={() => navigate("/login")} style={{ float: "right" }} color="warning">
                        Zaten bir hesabın var mı ?
                    </Button>
                </Form>
            </div>
        </Container>
    );
}

export default Register;
