-- �Խ��� � ����
-- �ܰ躰�� �׽�Ʈ�ϰ�, �����Ͱ� ����(insert, update, delete)�� �Ǹ� commit �Ѵ�.

-- 1. ����Ʈ - ��ȣ, ����, �ۼ���, �ۼ���, ��ȸ�� - �ֽű��� ������ ������ �Ѵ�.
select no, title, writer, writeDate, hit from board
order by no desc;

--  ���� �����Ͱ� �ִ� �Խñ� ��������.
select no, title, writer, writeDate, hit from board
where title like '%ȫ�浿%' or content like '%ȫ�浿%' or writer like '%ȫ�浿%' 
order by no desc;

-- 2. ����
--  - ��ȸ ����
update board set hit = hit + 1 where no = 2;
commit;
--  - ������ ������ - ��ȣ, ����, ����, �ۼ���, �ۼ���, ��ȸ��
select no, title, writer, writeDate, hit from board
where no = 2;

-- 3. ���� - ����, ����, �ۼ���, ��й�ȣ : �۹�ȣ - seq���� �޾ƿ´�.
insert into board(no, title, content, writer, pw)
values(board_seq.nextval, '������ ����', '��Ȯ�� ������.', 'ȫ�浿', '1111');
commit;

-- 4. ���� - ����, ����, �ۼ���. �۹�ȣ�� ��й�ȣ�� �¾ƾ� �����Ѵ�.
update board set title='��������', content = '��������', writer='�����'
where no = 2 and pw = '1111';
commit;

-- 5. ����
delete from board 
where no =2 and pw ='1111';
commit;