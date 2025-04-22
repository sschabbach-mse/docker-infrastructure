FROM mongo:8.0.8

#RUN openssl rand -base64 756 /data/keyfile
COPY ../keyfile.txt C:/keyfile

#RUN chmod 400 /data/keyfile
#RUN chown 999:999 /data/keyfile
#RUN ls -al /data/keyfile

ENTRYPOINT ["docker-entrypoint.sh"]
EXPOSE 27017

CMD ["mongod"]
