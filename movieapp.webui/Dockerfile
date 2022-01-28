FROM node:14-alpine AS development

WORKDIR /movieapp.webui

ENV PATH "./node_modules/.bin:$PATH"

COPY movieapp.webui/package.json .

RUN npm install

COPY movieapp.webui/. .

CMD ["npm", "run-script", "start"]