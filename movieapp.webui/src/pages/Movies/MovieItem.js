import { useNavigate } from "react-router-dom";
import { Button, Card, CardBody, CardImg, CardText, CardTitle } from "reactstrap";

export default function MovieItem(prop) {
    var navigate = useNavigate();
    var imageUrl = `https://image.tmdb.org/t/p/w500/${prop.imagePath}`;
    return (
        <Card style={{ maxWidth: "33%" }}>
            <CardImg
                alt={prop.title}
                src={imageUrl}
                top
                width="100%"
                height="80%"
            />
            <CardBody>
                <CardTitle tag="h5" style={{minHeight:"48px"}}>
                    {prop.title}
                </CardTitle>
                <CardText>
                    {String(prop.overview).substring(0, 25)}
                    {String(prop.overview).length <= 0 ? "Film açıklaması bulunamadı" : ""} 
                </CardText>
                <Button onClick={() => navigate("/movie/" + prop.id)}>
                    Görüntüle
                </Button>
            </CardBody>
        </Card>
    );
}