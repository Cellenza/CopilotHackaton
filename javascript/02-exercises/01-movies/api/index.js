import express from "express";
import bodyParser from "express";
import cors from "cors";
import morgan from "morgan";
import {Low} from 'lowdb'
import {JSONFile} from 'lowdb/node'
import swaggerUi from "swagger-ui-express";
import swaggerJsdoc from "swagger-jsdoc";
import MoviesRouter from "./routes/movies/movies.route.js";
import IndexRouter from "./routes/index.route.js";

const PORT = process.env.PORT || 8080;
// Swagger
const swaggerOptions = {
    definition: {
        openapi: "3.0.0",
        info: {
            title: "Movies API",
            version: "1.0.0",
            description: "A simple Express Movies API"
        },
        servers: []
    },
    apis: ["./routes/*/*.route.js"]
};
const specs = swaggerJsdoc(swaggerOptions);

const app = express();

// Create a database instance
const db = new Low(new JSONFile('db.json'), {});

// Read data from JSON file
db.read();

app.db = db;
const corsOptions = {
    origin: '*',
    optionsSuccessStatus: 200,
};
app.use(cors(corsOptions));
app.use(express.json());
app.use(bodyParser.json());
app.use(morgan("dev"));

app.use("/api-docs", swaggerUi.serve, swaggerUi.setup(specs));
app.use("/api/movies", MoviesRouter);
app.use("/", IndexRouter);

app.listen(PORT, () => {
    console.log(`Server is running on port ${PORT}.`);
});
