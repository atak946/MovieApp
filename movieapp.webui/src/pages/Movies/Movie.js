import { useEffect, useState } from 'react'
import { useParams } from 'react-router-dom';
import { Button, Col, Form, FormGroup, Input, Label, ListGroup, ListGroupItem, Row } from 'reactstrap';
import MovieService from "../../library/Movie/MovieService";
import MovieCommentService from "../../library/Movie/MovieCommentService";
import moment from 'moment'

function Movie() {
  const [movie, setMovie] = useState({});
  const [commentList, setCommentList] = useState([]);
  const [rate, setRate] = useState(0);
  const [comment, setComment] = useState("");
  const [rateAvg, setRateAvg] = useState(0);

  let { id } = useParams();

  async function GetMovie() {
    let response = await MovieService.Get(id);
    setMovie(response);
  }

  async function GetComments() {
    let response = await MovieCommentService.GetList(1, 100, id);
    setCommentList(response.data);

    const sum = Sum(response.data);
    const avg = (sum / response.data.length) || 0;
    setRateAvg(avg);
  }

  async function AddComment() {
    let response = await MovieCommentService.AddComment(id, comment, rate);
    GetComments();
    if (response.id !== undefined && response.id > 0)
      alert("Yorum başarıyla eklendi");
    else
      alert(response);
  }

  useEffect(() => {
    GetMovie();
    GetComments();
  }, []);

  return (
    <>
      <Row>
        <Col md="12" style={{ background: "#eee", margin: "10px", padding: "10px" }}>
          <Label><b>Filmin Adı:</b> {movie.title}</Label>
        </Col>
      </Row>
      <Row>
        <Col md="4">
          <img src={"https://image.tmdb.org/t/p/w500/" + movie.imagePath} style={{ width: "100%", height: "100%" }} />
        </Col>
        <Col md="8">
          <ListGroup>
            <ListGroupItem>
              <Label style={{ background: "#ddd", padding: 5 }}>Yayınlanma Tarihi: </Label> {movie.releaseDate}
            </ListGroupItem>
            <ListGroupItem>
              <Label style={{ background: "#ddd", padding: 5 }}>Ortalama Puan: </Label> {commentList.length > 0 ? rateAvg : "Henüz kimse puan vermedi"}
            </ListGroupItem>
            <ListGroupItem>
              {GetSection("Açıklama")}
              {String(movie.overview).length <= 0 ? "Açıklama bulunamadı" : movie.overview}
            </ListGroupItem>
          </ListGroup>
          <br />
          {GetSection("Yorum Yap")}

          <Form>
            <FormGroup>
              <Label>Puan</Label>
              <Input type='select' onChange={(evt) => setRate(evt.target.value)}>
                {GetSelectOptions(10)}
              </Input>
              <Label>Yorum</Label>
              <textarea rows="4" style={{ width: "100%" }} onChange={(evt) => setComment(evt.target.value)}></textarea>
              <Button onClick={AddComment}>
                Yorumu Kaydet
              </Button>
            </FormGroup>
          </Form>

          {GetSection("Yorum ve Değerlendirmeler")}
          <br />
          <br />
          {
            RenderComments(commentList)
          }
        </Col>
      </Row>
    </>
  );
}

function Sum(commentList){
  var rateSum = 0;
  commentList.forEach(element => {
    rateSum += element.rate;
  });

  return rateSum;
}

function GetSelectOptions(max) {
  var optionArr = [];
  for (let index = 1; index <= max; index++) {
    optionArr.push(<option key={index} value={index}>{index}</option>);
  }
  return optionArr;
}


function RenderComments(commentList) {
  return (
    <ListGroup key={1} style={{maxHeight: "300px", overflowX: "hidden", overflowY: "scroll"}}>
      {
        commentList.map((row, index) => {
          return (
            <div key={index}>
              <ListGroupItem key={index + "_1"}>Tarih: {moment(row.createDate).format("DD-MM-YYYY HH:mm:ss")} / Puan: {row.rate}</ListGroupItem>
              <ListGroupItem key={index + "_2"}>Comment: {row.comment}</ListGroupItem>
              <br />
            </div>
          )
        })
      }
    </ListGroup>
  );
}

function GetSection(text) {
  return <Label style={{ width: "100%", float: "left", textAlign: "center", background: "#ddd", padding: 5 }}>{text}</Label>;
}

export default Movie;
