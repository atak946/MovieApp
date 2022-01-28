import { useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom';
import { Button, Container, Form, FormGroup, Input, Label } from 'reactstrap';
import Auth from "../../library/Auth/Auth"

function Profile() {
    const [user, setUser] = useState({});

    var navigate = useNavigate();

    async function GetUser() {
        let response = await Auth.GetUser();
        setUser(response);
    }

    useEffect(() => {
        GetUser();
    }, []);

    return (
        <Container>
            <Form>
                <FormGroup>
                    <Label>Kullanıcı Adı</Label>
                    <Input type="text" readOnly value={user.userName ?? ""} />
                </FormGroup>
                <FormGroup>
                    <Label>Email</Label>
                    <Input type="text" readOnly value={user.email ?? ""} />
                </FormGroup>
                <FormGroup>
                    <Label>Telefon No</Label>
                    <Input type="text" readOnly value={user.phoneNumber ?? ""} />
                </FormGroup>
                <Button onClick={() => navigate("/logout")}>
                    Çıkış
                </Button>
            </Form>
        </Container>
    );
}

export default Profile;
